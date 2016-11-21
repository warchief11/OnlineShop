angular.module('shopApp').controller('ReservationsCtrl', ['$scope', 'Booking', function ($scope, Booking) {
    var reservationsModel = {};
    $scope.reservations = [{ Id: '1', gateName: '1', flightName: 'VA213', destination: 'Melbourne', arrival: '12:13', departure: '12:54', status: 'scheduled' }]

}]);