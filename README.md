# UnicamProgettoParadigmi
Progetto n.3 - Realizzazione di una web api che permetta la gestione di una lista di distribuzione 
multi utenza.
## Esecuzione del progetto
### Creazione Database
- Creare database utilizzando il dump presente nella cartella database/dump.sql.
- User Id = adminparadigmi
- Password = password
### Esecuzione
- Eseguire il progetto UnicamProgettoParadigmi.Web da cui partirà automaticamente Swagger.
### Registrazione e log in
- Registarsi utilizzando una mail non utilizzata e una password lunga almeno 6 caratteri e contenente almeno 1 maiuscola, 1 minuscola, 1 numero e 1 carattere speciale.
- Per il log in inserire email e password e si otterrà il token che è necessario per effettuare tutte le altre chiamate.
### Altre chiamate
- Chiamata di creazione di una lista di disitribuzione. Bisogna specificare un nome per la lista di distribuzione che non appartenga già ad una lista di distribuzione di cui l'utente è proprietario.
- Aggiunta email destinatario. Bisogna specificare il nome di una lista di distribuzione di cui si è proprietari alla quale si vuole aggiungere la email e una mail che non sia già presente in quella lista di distribuzione.
- Eliminazione email destinatario. Bisogna specificare il nome di una lista di distribuzione di cui si è proprietari alla quale si vuole rimuovere la email e una mail che sia presente in quella lista di distribuzione.
- Invio email. Si specifica il nome di una lista di distribuzione di cui si è proprietari e oggetto, testo e allegati della mail che si vuole inviare a tutti i partecipanti di quella lista.
- Dato un destinatario ottenere tutte le liste di distribuzione a lui associate. La ricerca pagina i risultati in base ai parametro passati nella chiamata. Vengono visualizzate solo le liste a cui la email è associata e di cui si è proprietari.
