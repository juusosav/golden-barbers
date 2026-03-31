window.cultureManager = {
    get: function () {
        return localStorage.getItem("culture");
    },
    set: function (value) {
        localStorage.setItem("culture", value);
        location.reload();
    }
};