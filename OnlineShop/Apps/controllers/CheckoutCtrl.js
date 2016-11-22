angular.module('shopApp')
    .controller('CheckoutCtrl', CheckoutCtrl);

CheckoutCtrl.$inject = ['$scope', 'Order'];

function CheckoutCtrl($scope, Order) {
    var vm = this;
    
    //TODO: remove hardcoding
    vm.getBasket = Order.getBasket().then(function (basket) {
        vm.basket = basket;
        vm.orderItems = basket.OrderItems;
    });

    vm.removeItem = function (id) {
        Order.removeFromBasket(id).then(function (response) {
            Order.getBasket().then(function (basket) {
                vm.basket = basket;
                vm.orderItems = basket.OrderItems;
            });
        });
    };

    vm.createOrder = function (id) {
        Order.createOrder(id).then(funct)
    }
    return vm;
};