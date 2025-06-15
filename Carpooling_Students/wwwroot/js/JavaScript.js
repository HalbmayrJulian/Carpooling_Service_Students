// Beispiel: Auto-Bildgröße dynamisch ändern
window.addEventListener('resize', function() {
    const carImage = document.querySelector('.car-image');
    if (window.innerWidth < 600) {
        carImage.style.maxWidth = '300px'; // Verkleinern bei kleinerer Bildschirmgröße
    } else {
        carImage.style.maxWidth = '400px'; // Standardgröße
    }
});

// Du kannst hier auch andere dynamische Anpassungen hinzufügen
// Funktion zur Ausgabe des aktuellen Datums im Format: Tag, Monat Jahr
function setCurrentDate() {
    const today = new Date();
    const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    const dateString = today.toLocaleDateString('de-DE', options); // Datum im deutschen Format
    if(document.getElementById('current-date')) {
        document.getElementById('current-date').innerText = dateString;
    })
}

// Datum setzen, wenn die Seite geladen wird
document.addEventListener('DOMContentLoaded', function() {
    setCurrentDate();
});
