# 🃏 Blackjack Network

Un joc de Blackjack multiplayer în rețea, dezvoltat în **C#** cu **Windows Forms**, folosind comunicare TCP/IP prin socket-uri. Doi jucători se conectează la un server central și joacă Blackjack în timp real.

---

##  Descriere

Proiectul implementează jocul clasic de Blackjack în variantă de rețea, cu arhitectură **client-server**. Serverul gestionează logica jocului, amestecul cărților, rândul jucătorilor și comunicarea în timp real. Fiecare client primește și trimite comenzi prin TCP, iar starea jocului este sincronizată automat între toți participanții.

---

##  Tehnologii

- **Limbaj:** C#
- **Framework:** .NET Framework (Windows Forms)
- **IDE:** Visual Studio 2022
- **Comunicare:** TCP/IP cu `System.Net.Sockets`
- **Concurență:** `System.Threading` (thread dedicat pentru server)

---

##  Structura proiectului

| Fișier | Rol |
|---|---|
| `Carte.cs` | Clasa care reprezintă o carte de joc (valoare + culoare) |
| `Pachet.cs` | Pachetul de cărți – amestecare și distribuire |
| `Participant.cs` | Clasă de bază pentru jucători și dealer |
| `Jucator.cs` | Logica unui jucător (mână, scor, resetare) |
| `Dealer.cs` | Logica dealer-ului (trage cărți până la scor minim) |
| `Joc.cs` | Orchestrează o rundă completă de joc |
| `Form_Server.cs` | Serverul TCP – acceptă conexiuni, procesează comenzi, trimite starea jocului |
| `Form_Conectare.cs` | Formularul clientului – conectare la server prin IP |
| `Form1.cs` / `Form2.cs` | Interfața grafică a clientului (vizualizare cărți, butoane HIT/STAND/RESET) |
| `Program.cs` | Punctul de intrare în aplicație |
| `BLACKJACK_IN_RETEA.sln` | Soluția Visual Studio |

---

##  Cum funcționează

### Server
1. Se lansează `Form_Server` care pornește automat un thread de ascultare pe **portul 5000**.
2. Acceptă exact **2 conexiuni** de la clienți; clienții suplimentari sunt respinși.
3. La conectarea celui de-al doilea jucător, jocul începe automat (amestec + împărțire cărți).
4. Procesează comenzile `HIT:<id>`, `STAND:<id>` și `RESET`, validând rândul curent.
5. Trimite starea actualizată a jocului (cărți, scoruri, rezultat) după fiecare comandă.

### Client
1. Se introduce IP-ul serverului în `Form_Conectare` și se apasă **Conectare**.
2. Clientul primește un ID (1 sau 2) de la server.
3. Jucătorul poate apăsa **HIT** (trage o carte) sau **STAND** (se oprește) când e rândul său.
4. Cărțile adversarului sunt **ascunse** până când acesta dă STAND.
5. La final, serverul calculează câștigătorul și afișează rezultatul.

### Protocol TCP (text ASCII)
```
Client → Server:   HIT:1 | STAND:2 | RESET | EXIT
Server → Client:   Jucator1:_As_Inima,...\nJucator2:...\nDealer:...\nScorJucator1:17\n...\nRAND:1\nEND
```

---

##  Reguli implementate

- Scopul jocului: să ajungi cât mai aproape de **21** fără să depășești.
- **Blackjack** la distribuirea inițială = jucătorul trece automat la STAND.
- Dacă scorul depășește 21, jucătorul **pierde** (bust).
- Dacă ambii jucători au terminat (STAND sau bust), **dealer-ul** joacă.
- Dealer-ul trage cărți până când scorul lui este suficient.
- Rezultate posibile: **CÂȘTIGĂ** / **PIERDE** / **REMIZĂ** / **BUST** / **BLACKJACK**.

---

##  Rulare

### Cerințe
- Windows cu .NET Framework instalat
- Visual Studio 2022

### Pași
1. Deschide `BLACKJACK_IN_RETEA.sln` în Visual Studio 2022.
2. Compilează soluția (`Ctrl+Shift+B`).
3. Rulează o instanță ca **Server** (pornește `Form_Server`).
4. Rulează două instanțe ca **Client** și conectează-le la IP-ul serverului (ex: `127.0.0.1` pentru localhost).
5. Jocul începe automat când ambii clienți sunt conectați.

---

##  Autor

**Bîrsan Ioan-Andrei**  
[github.com/andreiBirsanIoan](https://github.com/andreiBirsanIoan)
