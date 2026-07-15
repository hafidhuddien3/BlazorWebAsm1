window.iframeInterop = {
    sendMessage: function (iframeId, targetOrigin, message) {
        const iframe = document.getElementById(iframeId);

        if (!iframe) {
            console.error("Iframe not found:", iframeId);
            return;
        }

        iframe.contentWindow.postMessage(
            message,
            targetOrigin
        );
    }
};