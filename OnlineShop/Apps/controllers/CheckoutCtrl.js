angular.module('shopApp')
    .controller('CheckoutCtrl', CheckoutCtrl);

CheckoutCtrl.$inject = ['$scope', 'Order'];

function CheckoutCtrl($scope, Order) {
    var vm = this;
    //TODO: remove hardcoding
    this.getCart = Order.getOrder().then(function (order) {
        vm.order = order;
    });

    vm.removeItem = function (item) {
        Order.removeFromBasket(item);
        vm.getCart();
    };
    return vm;
};