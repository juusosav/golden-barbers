window.carousel = {
    intervalId: null,
    index: 1,

    init: function () {

        if (this.intervalId !== null) {
            clearInterval(this.intervalId);
        }

        this.index = 1;
        this.showSlide(this.index);

        this.intervalId = setInterval(() => {
            this.changeSlide(1);
        }, 4000);
    },

    changeSlide: function (n) {
        this.showSlide(this.index += n);
    },

    showSlide: function (n) {

        let slides = document.querySelectorAll(".slide");
        if (slides.length === 0) return;

        if (n > slides.length) this.index = 1;
        if (n < 1) this.index = slides.length;

        slides.forEach(s => s.classList.remove("active"));
        slides[this.index - 1].classList.add("active");
    }
};
