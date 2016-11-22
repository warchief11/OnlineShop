var app = angular.module("testModule", ["ui.router"]);

//TO DO: THIS NEEDS TO BE COMPLETED
app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

    //redirect if the router is unspecified
    $urlRouterProvider.otherwise('/init');

    $stateProvider
    //home router where all the posts are displayed
        .state('init', {
            url: '/init',
            template: '<p>This is init template.</p>'
        })

    //the login router
    .state('login', {
        url: '/login',
        template: '<p>This is login template.</p>'
    });

}]);

//service to be used by other controllers
app.factory('posts', [function () {
    var o = {
        posts: []
    };

    return o;

}]);