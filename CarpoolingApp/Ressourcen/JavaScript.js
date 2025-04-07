import mariadb from 'mariadb';

const pool = mariadb.createPool({
    host: '10.111.0.121', // IP-Adresse anpassen
    user: 'carpooladmin', // User anpassen
    password: 'cisco', // Passwort anpassen
    database: 'carpool',
    connectionLimit: 5
});

async function queryDatabase(query, params) {
    let connection;
    try {
        connection = await pool.getConnection();
        console.log('Verbindung erfolgreich hergestellt');
        const rows = await connection.query(query, params);
        return rows;
    } catch (err) {
        console.log('Verbindung fehlgeschlagen:', err);
        throw err;
    } finally {
        if (connection) connection.end();
    }
}

// Funktion zum Abrufen aller Personen
async function getAllPersons() {
    const query = 'SELECT * FROM Person';
    try {
        const persons = await queryDatabase(query);
        console.log('Personen:', persons);
        // Hier kannst du die Personen-Daten weiterverarbeiten oder anzeigen
    } catch (err) {
        console.error('Fehler beim Abrufen der Personen:', err);
    }
}

// Funktion zum Abrufen aller Routen
async function getAllRoutes() {
    const query = 'SELECT * FROM Route';
    return await queryDatabase(query);
}

// Funktion zum Abrufen aller Fahrten
async function getAllFahrten() {
    const query = 'SELECT * FROM Fahrt';
    return await queryDatabase(query);
}

// Funktion zum Abrufen aller Autofahrten
async function getAllAutofahrten() {
    const query = 'SELECT * FROM Autofahrt';
    return await queryDatabase(query);
}

// Funktion zum Abrufen aller Autofahrt-Passagiere
async function getAllAutofahrtPassangers() {
    const query = 'SELECT * FROM Autofahrt_Passanger';
    return await queryDatabase(query);
}

// Funktion zum Abrufen aller alternativen Fahrten
async function getAllAlternativeFahrten() {
    const query = 'SELECT * FROM AlternativeFahrt';
    return await queryDatabase(query);
}

// Funktion zum Abrufen aller Shops
async function getAllShops() {
    const query = 'SELECT * FROM Shop';
    return await queryDatabase(query);
}

// Funktion zum Abrufen aller Items
async function getAllItems() {
    const query = 'SELECT * FROM Items';
    return await queryDatabase(query);
}

// Funktion zum Abrufen aller Shop-Items
async function getAllShopItems() {
    const query = 'SELECT * FROM Shop_Items';
    return await queryDatabase(query);
}

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
    document.getElementById('current-date').innerText = dateString;
}

// Datum setzen, wenn die Seite geladen wird
document.addEventListener('DOMContentLoaded', function() {
    setCurrentDate();
});
