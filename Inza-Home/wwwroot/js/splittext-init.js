(function () {
    if (!window.gsap) return;
    gsap.registerPlugin(ScrollTrigger);

    // ---- fallback splitter (SplitText yoksa) ----
    function fallbackSplit(el, type) {
        const text = el.textContent;
        el.innerHTML = "";

        if (type === "words") {
            text.split(/(\s+)/).forEach(tok => {
                if (tok.trim()) {
                    const s = document.createElement("span");
                    s.className = "split-word";
                    s.textContent = tok;
                    el.appendChild(s);
                } else {
                    // boşlukları koru
                    el.appendChild(document.createTextNode(tok));
                }
            });
            return Array.from(el.querySelectorAll(".split-word"));
        }

        // default: chars
        for (const ch of text) {
            if (ch === " ") {
                el.appendChild(document.createTextNode(" "));
            } else {
                const s = document.createElement("span");
                s.className = "split-char";
                s.textContent = ch;
                el.appendChild(s);
            }
        }
        return Array.from(el.querySelectorAll(".split-char"));
    }

    // ---- tek bir elemanı başlat ----
    function initSplit(el) {
        const splitType = el.dataset.split || "chars";             // chars | words | lines
        const delayMs = parseInt(el.dataset.delay || "100", 10);
        const duration = parseFloat(el.dataset.duration || "0.6");
        const ease = el.dataset.ease || "power3.out";
        const threshold = parseFloat(el.dataset.threshold || "0.1"); // 0..1
        const rootMargin = el.dataset.rootMargin || "-100px";
        const fromConf = el.dataset.from ? JSON.parse(el.dataset.from) : { opacity: 0, y: 40 };
        const toConf = el.dataset.to ? JSON.parse(el.dataset.to) : { opacity: 1, y: 0 };

        let targets = [];
        let splitInstance = null;
        const hasSplitText = typeof window.SplitText === "function";

        try {
            if (hasSplitText && (splitType === "lines" || splitType === "words" || splitType === "chars")) {
                gsap.registerPlugin(window.SplitText);
                const absoluteLines = splitType === "lines";
                splitInstance = new window.SplitText(el, {
                    type: splitType,
                    absolute: absoluteLines,
                    linesClass: "split-line"
                });
                targets = splitType === "lines" ? splitInstance.lines :
                    splitType === "words" ? splitInstance.words :
                        splitInstance.chars;
            } else {
                // lines desteği yok, words/chars var
                targets = fallbackSplit(el, splitType === "words" ? "words" : "chars");
            }
        } catch (e) {
            console.error("SplitText init error:", e);
            return;
        }

        if (!targets.length) return;

        targets.forEach(t => { t.style.willChange = "transform, opacity"; });

        // React örneğindeki start hesabı
        const startPct = (1 - threshold) * 100;
        const mm = /^(-?\d+(?:\.\d+)?)(px|em|rem|%)?$/.exec(rootMargin);
        const mv = mm ? parseFloat(mm[1]) : 0;
        const mu = mm ? (mm[2] || "px") : "px";
        const sign = mv < 0 ? `-=${Math.abs(mv)}${mu}` : `+=${mv}${mu}`;
        const start = `top ${startPct}%${sign}`;

        const tl = gsap.timeline({
            scrollTrigger: {
                trigger: el,
                start,
                toggleActions: "play none none none",
                once: true
            },
            smoothChildTiming: true,
            onComplete: () => {
                gsap.set(targets, { ...toConf, clearProps: "willChange", immediateRender: true });
            }
        });

        tl.set(targets, { ...fromConf, immediateRender: false, force3D: true });
        tl.to(targets, { ...toConf, duration, ease, stagger: delayMs / 1000, force3D: true });

        return { tl, splitInstance };
    }

    // ---- sayfadaki tüm .split-text öğelerini başlat ----
    function initAll(scope) {
        (scope || document).querySelectorAll(".split-text").forEach(initSplit);
    }

    // ---- Bootstrap Carousel entegrasyonu ----
    function wireCarousel() {
        const car = document.getElementById("heroCarousel");
        if (!car) return;

        car.addEventListener("slid.bs.carousel", (e) => {
            const active = e.relatedTarget || car.querySelector(".carousel-item.active");
            if (!active) return;
            active.querySelectorAll(".split-text").forEach(node => {
                // reset: orijinal metne dön
                const original = node.dataset.originalText || node.textContent.trim();
                node.dataset.originalText = original;
                node.textContent = original;
                initSplit(node);
            });
        });
    }

    // ---- Boot: web fontları yüklendikten sonra başlat ----
    function boot() {
        initAll();
        wireCarousel();
    }

    document.addEventListener("DOMContentLoaded", function () {
        if (document.fonts && document.fonts.ready) {
            document.fonts.ready.then(boot);
        } else {
            window.addEventListener("load", boot, { once: true });
        }
    });
})();