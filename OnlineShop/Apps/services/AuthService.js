'use strict';

angular.module('shopApp').factory('AuthService', AuthService);

AuthService.$inject = ['$http', '$q', 'localStorageService']

function AuthService($http, $q, localStorageService) {

    var authServiceFactory = {};
    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _saveRegistration = function (registration) {
        _logOut();
        return $http.post('api/account/register', registration).then(function (response) {
            return response;
        });

    };

    var _login = function () {
        _logOut();
      //
    
    };
    
    var _logOut = function () {
        _authentication.isAuth = false;
        _authentication.userName = "";
    };

    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.saveRegistration = _saveRegistration;
    return authServiceFactory;
};