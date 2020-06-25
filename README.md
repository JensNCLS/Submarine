# Submarine
School project Zeeslag S2-DB01

## Werken in de repo
Wanneer je aan de slag gaat in de repo, gelieve te werken in jouw eigen branch (deze kan je gewoon aanmaken). 
Pull Requests met jouw gemaakte commits kan je maken tegen de dev-branch.
@Ikarago zal eens per week deze wijzigingen doorzetten naar de master-branch. Andere wijzigingen en Pull Requests die direct tegen de master branch worden uitgevoerd worden teruggedraaid (tenzij anders afgesproken).

## Uitleg projecten
### Back-end
- Submarine.GameLogic ** --> Backend met de eigen Game Logica
- Submarine.ServiceBus --> Koppeling backend met Service Bus (deze zal de vertaalslag doen)
- Submarine.Core ** --> Koppelt de ServiceBus en GameLogic voor de Front-End

** = Referenties benodigd in de Front-end voor juiste werking

### Front-end
- Submarine.Web --> ASP.Net Web front-end
