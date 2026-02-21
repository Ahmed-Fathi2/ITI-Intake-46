
        function toggleMenu() {
            var menu = document.getElementById('mobileMenu');
            menu.classList.toggle('hidden');
        }

        function toggleDarkMode() {
            document.body.classList.toggle('dark-mode');
        }

        function handleSubmit(event) {
            event.preventDefault();
            alert('Thank you for your message! We will get back to you soon.');
            event.target.reset();
        }
    