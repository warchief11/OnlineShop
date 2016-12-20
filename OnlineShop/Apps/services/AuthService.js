'use strict';

angular.module('shopApp').factory('AuthService', AuthService);

AuthService.$inject = ['$http', '$q', '$localStorage', 'ngAppSettings']

function AuthService($http, $q, $localStorage, ngAppSettings) {

    var authServiceFactory = {};
    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _signUp = function (registration) {
        _logOut();
        var deferred = $q.defer();
        return $http.post(ngAppSettings.apiServiceBaseUri + 'api/account/register', registration).then(function (response) {
            deferred.resolve(response);
            return response;
        },
        function (response) {
            deferred.reject(err);
            return response;
        });

    };

    var _login = function (loginData) {
        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post(ngAppSettings.apiServiceBaseUri + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

            $localStorage.authorizationData = { token: response.access_token, userName: loginData.userName };

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;
    };
    
    var _logOut = function () {
        _authentication.isAuth = false;
        _authentication.userName = "";
    };
    var _fillAuthData = function () {

        var authData = localStorageService.authorizationData;
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }

    };

    authServiceFactory.signUp = _signUp;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    return authServiceFactory;
};