angular.module('shopApp')
    .controller('LoginCtrl', LoginCtrl);

LoginCtrl.$inject = ['$scope', '$timeout', 'AuthService'];

function LoginCtrl($scope, $timeout, AuthService) {
    var vm = this;
    vm.registration = {
        userName: "",
        password: "",
        confirmPassword: ""
    };

    vm.loginData = {
        userName: "",
        password: ""
    };

    vm.message = "Register new user account";
    vm.savedSuccessfully = false;
    vm.signUp = function () {
        AuthService.signUp(vm.registration).then(function (response) {
            vm.savedSuccessfully = true;
            vm.message = "User has been registered successfully, you will be redirected to login page in 2 seconds.";
        },
        function (response) {
            var errors = [];
            for (var key in response.data.modelState) {
                for (var i = 0; i < response.data.modelState[key].length; i++) {
                    errors.push(response.data.modelState[key][i]);
                }
            }
            message = "Failed to register user due to:" + errors.join(' ');
        });
    };

    vm.login = function () {
        AuthService.login(vm.loginData);
    }

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/logIn');
        }, 2000);
    }


    return vm;
};