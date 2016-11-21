angular.module('shopApp')
    .controller('CheckoutCtrl', CheckoutCtrl);

CheckoutCtrl.$inject = ['$scope', 'Order'];

function CheckoutCtrl($scope, Order) {
    var vm = this;
    //TODO: remove hardcoding
    Order.getOrder().then(function (order) {
        vm.order = order;
    });

    return vm;
};