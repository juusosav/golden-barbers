window.getBrowserCulture = () => {
    return localStorage.getItem("culture")
        || navigator.language
        || "en";
};

window.setCulture = (culture) => {
    localStorage.setItem("culture", culture);
}