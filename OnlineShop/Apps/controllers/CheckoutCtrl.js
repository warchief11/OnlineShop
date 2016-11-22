angular.module('shopApp')
    .controller('CheckoutCtrl', CheckoutCtrl);

CheckoutCtrl.$inject = ['$scope', 'Order'];

function CheckoutCtrl($scope, Order) {
    var vm = this;
    //TODO: remove hardcoding
    vm.getCart = Order.getOrder().then(function (order) {
        vm.order = order;
    });

    vm.removeItem = function (id) {
        Order.removeFromBasket(id);
        vm.getCart();
    };
    return vm;
};