angular.module('shopApp').service('Order', ['$http', '$q', function ($http, $q) {
    'use strict';

    var items = null;

    this.getItems = function () {
        return $http.get('api/menu').then(function (response) {
            items = response.data;
            isMenuLoaded = true;
            return items;
        });
    };

    this.addToBasket = function (item) {
        return $http.post('api/basket/1/item', item).then(function () {
            return getBasket();
        })
    };

    this.removeFromBasket = function (id) {
        return $http('delete','api/basket/1/item/' + id).then(function (response) {
            return this.getItems();
        })
    };

    this.getBasket = function () {
        return $http.get('api/basket').then(function (response) {
            return response.data;
        });
    };

    this.getOrder = function () {
        return $http.get('api/order/1').then(function (response) {
            var order = response.data;
            return order;
        });
    };
}])