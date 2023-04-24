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

    function checkDataAcceptance(input) {
        if (input.checked !== true) {
            input.classList.add('invalid-val');
            return false;
        }
        input.classList.remove('invalid-val');
        return true;
    }


    if (form) {
        form.addEventListener('submit', e => {
            e.preventDefault();

            const formData = new FormData(form);

            var input = document.getElementById('field_jy2v2');
            var dataAcceptanceInput = document.getElementById('data-acceptance');

            var isDataAccepted = checkDataAcceptance(dataAcceptanceInput);
            var messageValid = checkMessage(input);

            if (messageValid && isDataAccepted) {
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