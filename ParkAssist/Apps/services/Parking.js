angular.module('shopApp').service('Parking', ['$http', '$q', function ($http, $q) {
   'use strict';

   this.getReservations = function (gateId) {

       return $http.get('api/reservations/?gateId=' + gateId).then(function (response) {
           return response.data;
       });

       var reservations = [{ Id: 1, gateId: 1, gateName: "1A", flightId: 1, flightName: 'CA124', destination: 'Melbourne', arrival: '04:30', departure: '05:59', status: 'scheduled' },
                            { Id: 2, gateId: 4, flightId: 2, flightName: 'QA566', destination: 'Auckland', arrival: '13:30', departure: '14:29', status: 'scheduled' }]
       return $q.when(reservations);
   };

   var gates = null;
   var isGatesLoaded = false;

   this.getGates = function () { 
       if(isGatesLoaded){
           return $q.when(gates);
       }
       else
       {
          return $http.get('api/gates').then(function (response) {
               gates = response.data;
               isGatesLoaded = true;
               return gates;
           });
       }
   };
}])