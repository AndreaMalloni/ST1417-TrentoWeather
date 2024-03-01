# [ST1417] - TrentoWeather
Progetto sviluppato dagli studenti [Daniele Monaldi](https://github.com/danielemonaldi), [Andrea Malloni](https://github.com/AndreaMalloni) e [Francesca Morici](https://github.com/Frangiosc) per il conseguimento della seconda parte dell'esame di **Applicazioni Web, Mobile e Cloud** del corso di Informatica per la comunicazione digitale (A.A. 2023-2024). [Consulta prima parte](https://github.com/AndreaMalloni/ST1417-TerraViva). 

## Descrizione
Il progetto prevede l'implementazione di un software **ASP .NET Core MVC** che consenta la visualizzazione dei dati relativi al bollettino metereologico della città di Trento disponibili al seguente [indirizzo](https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO). La specifica richiede inoltre che il software recuperi tali informazioni non in maniera diretta, bensì sfruttando un servizio **SOAP**, che invece dovrà ottenere le informazioni dallàindirizzo fornito e renderle disponibili in un formato stabilito. Il progetto dovrebbe infine essere eseguibile allàinterno di un container **Docker**.

## Implementazione
Il progetto è stato realizzatto tramite la suddivisione di quanto commissionato in 3 sottoprogetti:

- [[TrentoWeather_MVC](TrentoWeather_MVC)] progetto inerente l'applicazione di visualizzazione dei dati.
- [[TrentoWeather_SOAP](TrentoWeather_SOAP)] progetto inerente il servizio di recupero delle informazioni.
- [[WeatherModels](WeatherModels)] progetto contenente modelli di utilità comuni.

Tutti i sottoprogetti sono stati in ogni caso inclusi in una unica [soluzione](ST1417-TrentoWeather.sln).

## Esecuzione
Sia il software MVC che il servizio SOAP sono stati configurati per l'esecuzione attraverso un [docker-compose](docker-compose.yml) e mappati con una porta **interna** 80. Per quanto riguarda invece le porte esterne:

- **TrentoWeather_MVC**: al progetto MVC è stata assegnata la porta **1111**.
- **TrentoWeather_SOAP**: al progetto è stata assegnata la porta **2222**, con endpoint **/Service.wsdl**.
