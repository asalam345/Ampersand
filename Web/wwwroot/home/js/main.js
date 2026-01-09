window.initHomeTemplate = function () {

    "use strict";
    // ===== PRELOADER (FIXED)
    $('.preloader').fadeOut(500, function () {
        $(this).remove();
    });

    // ===== STICKY HEADER
    $(window).off('scroll.sticky').on('scroll.sticky', function () {
        var scroll = $(window).scrollTop();
        $(".header_navbar").toggleClass("sticky", scroll >= 20);
    });

    // ===== NAVBAR
    $(".navbar-toggler").off('click').on('click', function () {
        $(this).toggleClass("active");
    });

    $(".navbar-nav a").off('click').on('click', function () {
        $(".navbar-collapse").removeClass("show");
        $(".navbar-toggler").removeClass("active");
    });

    // ===== MAIN SLIDER
    if ($('.slider-active').length && !$('.slider-active').hasClass('slick-initialized')) {
        $('.slider-active').slick({
            autoplay: true,
            autoplaySpeed: 6000,
            dots: true,
            fade: true,
            arrows: false
        });
    }

    // ===== CUSTOMER SLIDER
    if ($('.customer_active').length && !$('.customer_active').hasClass('slick-initialized')) {
        $('.customer_active').slick({
            dots: true,
            infinite: true,
            speed: 800,
            slidesToShow: 2,
            arrows: false,
            responsive: [
                { breakpoint: 992, settings: { slidesToShow: 1 } }
            ]
        });
    }

    // ===== WOW
    if (window.WOW) {
        new WOW({ mobile: false }).init();
    }

    // ===== BACK TO TOP
    $(window).off('scroll.top').on('scroll.top', function () {
        $('.back-to-top').toggle($(this).scrollTop() > 600);
    });

    $('.back-to-top').off('click').on('click', function (e) {
        e.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, 1500);
    });
};
