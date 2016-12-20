console.log("DashboardController is loaded..");
angular.module('shopApp')
    .controller('DashboardCtrl', DashboardCtrl);

DashboardCtrl.$inject = ['$scope', '$uibModal', 'Order', ];

function DashboardCtrl($scope, $uibModal, Order) {
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

    vm.displayItemDetail = function (item) {
        $uibModal.open({
            animation: true,
            templateUrl: 'Apps/templates/itemDetail.html'
        })
    }
    return vm;
};