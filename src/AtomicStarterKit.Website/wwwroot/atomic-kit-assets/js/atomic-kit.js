(function() {
  "use strict"; // Start of use strict

  var mainNav = document.querySelector('#mainNav');

  if (mainNav) {

    var navbarCollapse = mainNav.querySelector('.navbar-collapse');
    
    if (navbarCollapse) {
      
      var collapse = new bootstrap.Collapse(navbarCollapse, {
        toggle: false
      });
      
      var navbarItems = navbarCollapse.querySelectorAll('a');
      
      // Closes responsive menu when a scroll trigger link is clicked
      for (var item of navbarItems) {
        item.addEventListener('click', function (event) {
          collapse.hide();
        });
      }
    }

    // Collapse Navbar
    var collapseNavbar = function() {

      var scrollTop = (window.pageYOffset !== undefined) ? window.pageYOffset : (document.documentElement || document.body.parentNode || document.body).scrollTop;

      if (scrollTop > 100) {
        mainNav.classList.add("navbar-shrink");
      } else {
        mainNav.classList.remove("navbar-shrink");
      }
    };
    // Collapse now if page is not at top
    collapseNavbar();
    // Collapse the navbar when page is scrolled
    document.addEventListener("scroll", collapseNavbar);

    // Hide navbar when modals trigger
    var modals = document.querySelectorAll('.portfolio-modal');
      
    for (var modal of modals) {
      
      modal.addEventListener('shown.bs.modal', function (event) {
        mainNav.classList.add('d-none');
      });
        
      modal.addEventListener('hidden.bs.modal', function (event) {
        mainNav.classList.remove('d-none');
      });
    }
  }

    var form = document.querySelector('#contactForm');

    function checkMessage(input) {
        var isName = input.value.trim();
        if (isName) {
            input.classList.remove('invalid');
            input.classList.add('valid');
            input.nextElementSibling.classList.remove('error_show');
            return true;
        } else {
            input.nextElementSibling.classList.add('error_show');
            input.classList.remove('valid');
            input.classList.add('invalid');
            return false;
        }
    }

    function checkDataAcceptance(input) {
        var isChecked = input.checked;
        if (isChecked) {
            input.classList.remove('invalid');
            input.classList.add('valid');
            input.nextElementSibling.nextElementSibling.classList.remove('error_show');
            return true;
        } else {
            input.nextElementSibling.nextElementSibling.classList.add('error_show');
            input.classList.remove('valid');
            input.classList.add('invalid');
            return false;
        }
    }


    if (form) {
        form.addEventListener('submit', e => {
            e.preventDefault();

            const formData = new FormData(form);
            var input = document.getElementById('field_jy2v2');
            var inputDataAcceptance = document.getElementById('data-acceptance');
            var messageValid = checkMessage(input);
            var isDataAcceptanceChecked = checkDataAcceptance(inputDataAcceptance);
            if (messageValid && isDataAcceptanceChecked) {
                fetch('/ContactForm/Submit', {
                    method: 'POST',
                    body: formData
                })
                    .then(response => {
                        if (response.ok) {
                            location.reload();
                        } else {
                            return;
                        }
                    })
                    .catch(error => {
                        return;
                    });
            } else {
                return;
            }
        });
    }

})(); // End of use strict