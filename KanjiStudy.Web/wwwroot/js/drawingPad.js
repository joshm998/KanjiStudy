(function () {
    window.createCanvasElement = (id) => {
        const canvas = document.getElementById(id);
        const ctx = canvas.getContext('2d');

        const sketch = document.getElementById('sketch');
        canvas.width = 500;
        canvas.height = 250;

        const mouse = { x: 0, y: 0 };

        /* Mouse Capturing Work */
        canvas.addEventListener('mousemove', function (e) {
            mouse.x = e.pageX - this.offsetLeft;
            mouse.y = e.pageY - this.offsetTop;
        }, false);

        ctx.lineJoin = 'round';
        ctx.lineCap = 'round';

        ctx.strokeStyle = "black";

        canvas.addEventListener('mousedown', function (e) {
            ctx.beginPath();
            ctx.moveTo(mouse.x, mouse.y);

            canvas.addEventListener('mousemove', onPaint, false);
        }, false);

        canvas.addEventListener('mouseup', function () {
            canvas.removeEventListener('mousemove', onPaint, false);
        }, false);

        const onPaint = function () {
            ctx.lineTo(mouse.x, mouse.y);
            ctx.stroke();
        };

    };
    window.clearCanvasElement = (id) => {
        const canvas = document.getElementById(id);
        const ctx = canvas.getContext('2d');
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    };
    window.getCanvasContent = (id) => {
       const canvas = document.getElementById(id);
       return canvas.toDataURL();
    }
})();