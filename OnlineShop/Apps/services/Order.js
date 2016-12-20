angular.module('shopApp').service('Order', ['$http', '$q', 'ngAppSettings', function ($http, $q, ngAppSettings) {
    'use strict';

    this.getItems = function () {
        return $http.get(ngAppSettings.apiServiceBaseUri + 'api/menu').then(function (response) {
            return response.data;
        });
    };

    this.addToBasket = function (item) {
        return $http.post(ngAppSettings.apiServiceBaseUri + 'api/basket/1/item', item).then(function () {
        });
    };

    this.removeFromBasket = function (id) {
        return $http.delete(ngAppSettings.apiServiceBaseUri + 'api/basket/1/item/' + id).then(function () {
        });
    };

    this.getBasket = function () {
        return $http.get(ngAppSettings.apiServiceBaseUri + 'api/basket').then(function (response) {
            return response.data;
        });
    };

    this.getOrder = function () {
        return $http.get(ngAppSettings.apiServiceBaseUri + 'api/order/1').then(function (response) {
            var order = response.data;
            return order;
        });
    };
    this.createOrder = function () {
        return $http.post(ngAppSettings.apiServiceBaseUri + 'api/order').then(function (response) {
            return response.data;
        });
    };
}])