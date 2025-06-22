# Firmen-Adressbuch

Dieses einfache Konsolenprogramm ermöglicht die Verwaltung von Firmenkontakten.  
Es bietet grundlegende Funktionen zum Hinzufügen, Suchen, Bearbeiten und Löschen von Adressen in einem Adressbuch.

---

## Zusammenfassung

- Konsolenbasiertes Adressbuch in C#
- Kontakte hinzufügen, anzeigen und löschen
- Eingabevalidierung für korrekte Kontaktdaten
- Intuitive Menüführung für einfache Bedienung
- Speicherung aller Adressen in einer JSON-Datei zur dauerhaften Datensicherung

## Features

### Adresse hinzufügen (AddAdress)

Diese Funktion ermöglicht es dem Benutzer, eine neue Adresse über die Konsole hinzuzufügen. Dabei werden folgende Schritte durchlaufen:

1. **Eingabe der persönlichen Daten**  
   - Vorname: Der Benutzer wird aufgefordert, einen Vornamen einzugeben. Der Name darf nicht leer sein und keine Zahlen enthalten.  
   - Nachname: Analog zum Vornamen, gültiger Nachname ohne Zahlen.

2. **Eingabe der Adresse**  
   - Straße: Die Eingabe muss sowohl Buchstaben als auch eine Hausnummer enthalten (z.B. "Musterstrasse 11").  
   - Stadt: Name der Stadt, darf keine Zahlen enthalten.  
   - Postleitzahl: Muss genau 4 Ziffern enthalten (z.B. "1111").

3. **Telefonnummer**  
   - Die Telefonnummer kann optional mit einem Pluszeichen (+) beginnen und darf nur Ziffern, Leerzeichen und optional einen Schrägstrich enthalten.

4. **Anzeige der eingegebenen Daten**  
   - Nach der Eingabe werden alle Daten formatiert in der Konsole angezeigt, z.B.:

     ```
     Max Mustermann  
     Musterstrasse 11  
     1111 Musterstadt  
     Phone: 111111111
     ```

5. **Bestätigung zum Speichern**  
   - Der Benutzer wird gefragt, ob die Adresse gespeichert werden soll (`Adresse speichern? (Y) Yes  (N) No`).  
   - Bei Bestätigung wird die Adresse im Adressbuch (JSON-Datei) gespeichert, bei Ablehnung verworfen.

**Validierung:**  
Jede Eingabe wird direkt auf Gültigkeit geprüft und bei fehlerhaften Eingaben erfolgt eine Fehlermeldung mit der Aufforderung zur erneuten Eingabe.

So wird sichergestellt, dass nur korrekte und vollständige Adressdaten gespeichert werden.

Die Adresse wird danach in der Liste der erfassten Adressen hinzugefügt und in einer Json-Datei gespeichert
Dem Benutzer wird eine Bestätigung für das erfolgreiche Anlegen einer neuen Adresse oder der Grund des Fehlschlagens angezeigt


### Adresse finden (FindAdress)

Diese Funktion ermöglicht es dem Benutzer, eine Adresse anhand von Vorname und Nachname zu finden. 

1. **Eingabe der der Namen**  
   - Vorname: Der Benutzer wird aufgefordert, einen Vornamen einzugeben. Der Name darf nicht leer sein und keine Zahlen enthalten.  
   - Nachname: Analog zum Vornamen, gültiger Nachname ohne Zahlen.

**Die Suche in der Liste wird case-insensitive durchgeführt

2. **Anzeige des Suchergebnis**
	- Wird eine Adresse gefunden die dem eingegeben Nachnamen und Vornamen entspricht wird sie in der Konsole angezeigt
	Ansonsten wird ausgegeben dass keine Adresse gefunden wurde die den Suchkriterien entspricht

### Adresse löschen (RemoveAddress)

Diese Funktion ermöglicht es dem Benutzer, eine Adresse anhand von Vorname und Nachname zu finden und diese dann auf Wunsch zu löschen.

1. **Eingabe der der Namen**  
   - Vorname: Der Benutzer wird aufgefordert, einen Vornamen einzugeben. Der Name darf nicht leer sein und keine Zahlen enthalten.  
   - Nachname: Analog zum Vornamen, gültiger Nachname ohne Zahlen.

2. **Anzeige des Suchergebnis**
	- Wird eine Adresse gefunden die dem eingegeben Nachnamen und Vornamen entspricht wird sie in der Konsole angezeigt
	Ansonsten wird ausgegeben dass keine Adresse gefunden wurde die den Suchkriterien entspricht

5. **Bestätigung zum Löschen**  
   - Der Benutzer wird gefragt, ob die Adresse gelöscht werden soll (`Adresse löschen? (Y) Yes  (N) No`).  
   - Bei Bestätigung wird die Adresse aus der aktuellen Adressliste gelöscht und die Änderungen gespeichert, bei Ablehnung wird der Vorgang abgebrochen..

### Anzeige aller Adressen (ShowAllAddresses)

Einfache Ausgabe aller gespeicherten Adressen