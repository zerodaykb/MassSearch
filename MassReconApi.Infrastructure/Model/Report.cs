using System.Collections.Generic;

//DOTNET

//    4 i wyzej zwalnia z egzanimu, na cwiczeniach kolokwium 4 zjazd (13 kwietnia) i projekt do oddania. Projekt powinien zawierac : 
//    * Entity framework
//    * REST API
//    * Wzorce projektowe
//    * Testy jednostkowe -> Xunit
//    + front - UI (można polaczyc z Angularem), nie jest konieczne ale duzy plus

//ANGULAR

//    3:
//    • Projekt wykorzystujący minimum 3 komponenty, które komunikują się ze sobą przez
//    mechanizm atrybutów oraz zdarzeń
//    3,5:
//    • Projekt ma posiadać formularz z walidacją pól (Reactive Forms)
//    • Własne walidatory pól
//    4:
//    • Wykorzystanie modułu do nawigacji (Router Module) między komponentami
//    • Aplikacja ma być podzielona na moduły (minimum 2)
//    4,5:
//    • Wykorzystanie modułu http do wykonywania zapytań http do wybranego przez siebie
//    serwisu internetowego
//    • Wykorzystanie kolekcji Observable z biblioteki Rx.
//    5:
//    • Wykorzystanie dowolnych gotowych bibliotek z modułami do Angualra . Np.:
//    o Material Design
//    o Google Maps
//    o Goodle Charts
//    o Inne ..

namespace MassReconApi.Infrastucture.Model
{
    public class Report : Entity
    {
        
        public string SearchPhrase { get; set; }
        public IEnumerable<ReportItem> ReportItems { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public int NumberOfItems { get; set; }
        
    }
}