angular.module('shopApp').service('Order', ['$http', '$q', function ($http, $q) {
    'use strict';

    var items = null;
    var isMenuLoaded = false;

    this.getItems = function () {
        if (isMenuLoaded) {
            return $q.when(items);
        }
        else {
            return $http.get('api/menu').then(function (response) {
                items = response.data;
                isMenuLoaded = true;
                return items;
            });
        }
    };

    
    this.getCart = function () {
        return $http.get('api/cart').then(function (response) {
            var cart = response.data;
            isMenuLoaded = true;
            return cart;
        });
    };

    this.getOrder = function () {
        return $http.get('api/order/1').then(function (response) {
            var order = response.data;
            return order;
        });
    };
}])