window.cultureManager = {
    get: function () {
        return localStorage.getItem("culture");
    },
    set: function (value) {
        localStorage.setItem("culture", value);
        history.replaceState(null, null, location.pathname + location.search);
        location.reload();
    }
};