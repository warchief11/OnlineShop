/// <reference path="flightParkModule.js" />
angular.module('shopApp')
    .controller('DashboardCtrl', DashboardCtrl);

DashboardCtrl.$inject = ['$scope', 'Order'];

function DashboardCtrl($scope, Order) {
    var vm = this;

    Order.getItems().then(function (items) {
        vm.items = items;
        $scope.items = items;
    });
   
    vm.gateSelected = function () {
        Parking.getReservations(vm.selectedGate.Id).then(function (reservations) {
            vm.reservations = reservations;
        });
    };

    vm.addToBasket = function (item) {
        vm.items = Order.addToBasket(item)
    }
    return vm;
};