window.navHelper = {
    closeMenu: function () {
        const toggler = document.getElementById('nav-toggle');
        if (toggler) {
            toggler.checked = false;
        }

        const navCollapse = document.getElementById('nav-toggle');
        if (navCollapse && window.bootstrap) {
            const collapse = bootstrap.Collapse.getInstance(navCollapse);
            if (collapse) collapse.hide();
        }
    }
}