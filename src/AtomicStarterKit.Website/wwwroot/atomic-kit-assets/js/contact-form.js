(function () {
    "use strict";

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


    if (form) {
        form.addEventListener('submit', e => {
            e.preventDefault();

            const formData = new FormData(form);
            var input = document.getElementById('field_jy2v2');
            var messageValid = checkMessage(input);
            if (messageValid) {
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
})(); 