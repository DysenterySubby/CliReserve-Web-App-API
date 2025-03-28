(function () {
    const video = document.getElementById('video');
    const canvasElement = document.getElementById('canvas');
    const canvas = canvasElement.getContext('2d', { willReadFrequently: true }); // Set willReadFrequently to true
    const outputMessage = document.getElementById('outputMessage');
    const outputData = document.getElementById('outputData');

    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        navigator.mediaDevices.getUserMedia({ video: { facingMode: 'environment' } }).then(function (stream) {
            video.srcObject = stream;
            video.setAttribute('playsinline', true); // needed to tell iOS safari we don't want fullscreen
            video.play();
            requestAnimationFrame(tick);
        }).catch(function (err) {
            console.error("Error accessing the camera: " + err);
        });
    } else {
        alert("getUserMedia not supported by your browser.");
    }

    function tick() {
        if (video.readyState === video.HAVE_ENOUGH_DATA) {
            canvasElement.height = video.videoHeight;
            canvasElement.width = video.videoWidth;
            canvas.drawImage(video, 0, 0, canvasElement.width, canvasElement.height);
            const imageData = canvas.getImageData(0, 0, canvasElement.width, canvasElement.height);
            const code = jsQR(imageData.data, imageData.width, imageData.height, {
                inversionAttempts: "dontInvert",
            });
            if (code) {
                outputMessage.hidden = true;
                outputData.innerText = code.data;

                // Send image data to server
                sendImageData(code);
            } else {
                outputMessage.hidden = false;
                outputData.innerText = "";
            }
        }
        requestAnimationFrame(tick);
    }

    function sendImageData(code) {

        fetch('/api/book/approve/' + code.data, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'text/plain; charset=utf-8',
            }
        })
    }
})();