document.addEventListener("DOMContentLoaded", () => {
    const canvas = document.getElementById("threadsCanvas");
    if (!canvas) return;

    const renderer = new OGL.Renderer({ canvas, alpha: true });
    const gl = renderer.gl;
    gl.clearColor(0.2, 0.1, 0.05, 1); // kahverengi arka plan test

    const geometry = new OGL.Triangle(gl);
    const program = new OGL.Program(gl, {
        vertex: `
            attribute vec2 position;
            void main() {
                gl_Position = vec4(position, 0.0, 1.0);
            }
        `,
        fragment: `
            precision highp float;
            void main() {
                gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0); // beyaz üçgen
            }
        `
    });

    const mesh = new OGL.Mesh(gl, { geometry, program });

    function resize() {
        renderer.setSize(canvas.clientWidth, canvas.clientHeight);
    }
    window.addEventListener("resize", resize);
    resize();

    function update() {
        renderer.render({ scene: mesh });
        requestAnimationFrame(update);
    }
    update();
});
