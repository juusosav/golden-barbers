window.scrollService = {
    scrollToElement: function (elementId) {
        const element = document.getElementById(elementId)

        if (element) {
            element.scrollIntoView({
                behavior: "smooth",
                block: "start"
            });
        }
    }
};