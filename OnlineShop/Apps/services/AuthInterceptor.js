'use Strict'

angular.module('shopApp').factory('AuthInterceptor', AuthInterceptor);

AuthInterceptor.$inject = ['$log', '$q', '$localStorage', '$location'];

function AuthInterceptor($log, $q, $localStorage, $location) {

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = $localStorage.authorizationData
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token
        };
        return config;
    };

    //var _responseError = function (rejection) {
    //    if (rejection.status = '401') {
    //        $location.path('/login');
    //    }
    //    return rejection;
    //};

    return {
        request: _request
       // responseError: _responseError
    };
    return {};
};