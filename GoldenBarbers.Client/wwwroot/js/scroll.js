window.scrollService = {
    scrollToElement: function (elementId) {
        const element = document.getElementById(elementId)

        if (element) {
            element.scrollIntoView({
                behavior: "smooth"
            });
        }
        else setTimeout(() => scrollService.scrollToElement(elementId), 50);
    }
};