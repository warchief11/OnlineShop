/// <reference path="flightParkModule.js" />
angular.module('shopApp')
    .controller('DashboardCtrl', DashboardCtrl);

DashboardCtrl.$inject = ['$scope', 'Parking', 'Order'];

function DashboardCtrl($scope, Parking, Order) {
    var vm = this;

    Parking.getReservations(vm.gateId).then(function (reservations) {
        vm.reservations = reservations;
    });
    Parking.getGates().then(function (gates) {
        vm.gates = gates;
        $scope.gates = gates;
        vm.selectedGate = gates[0];
    });

    Order.getItems().then(function (items) {
        vm.items = items;
        $scope.items = items;
    });
   
    vm.gateSelected = function () {
        Parking.getReservations(vm.selectedGate.Id).then(function (reservations) {
            vm.reservations = reservations;
        });
    };

    vm.addToCart = function (id) {
        
    }
    return vm;
};