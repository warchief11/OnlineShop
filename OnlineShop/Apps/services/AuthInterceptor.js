'use Strict'

angular.module('shopApp').factory('AuthInterceptor', AuthInterceptor);

AuthInterceptor.$inject = ['$log', '$q', '$localStorage', '$injector', '$location'];

function AuthInterceptor($log, $q, $localStorage, $injector, $location) {

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = $localStorage.authorizationData
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token
        };        
        return config;
    };


    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            var authService = $injector.get('AuthService');
            var authData = localStorageService.authorizationData;

            
            authService.logOut();
            $location.path('/login');
        }
        return $q.reject(rejection);
    }
    

    return {
        request: _request,
        responseError: _responseError
    };
};