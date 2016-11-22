/// <reference path="flightParkModule.js" />
angular.module('shopApp')
    .controller('DashboardCtrl', DashboardCtrl);

DashboardCtrl.$inject = ['$scope', 'Order'];

function DashboardCtrl($scope, Order) {
    var vm = this;
    vm.addingToCart = false;

    vm.getMenu = Order.getItems().then(function (items) {
        vm.items = items;
    });

    vm.addToBasket = function (item) {
        vm.addingToCart = true;
        Order.addToBasket(item).then(function () {
            vm.addingToCart = false;
        });
    };
    return vm;
};