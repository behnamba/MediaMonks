"use strict";

angular.module("assignmentApp").controller("assignmentMainController", ["$scope", "$sce", "$q", "$log", "$filter", "assignmentBackendService",
        function ($scope, $sce, $q, $log, $filter, assignmentBackendService) {
            var main = this;
            main.title = "Plan Day Payment Rule Engine Assignment :-)";

            // invisible log panel
            main.showLog = false;

            // show loading
            main.showLoading = false;

            // to optimize the performance of the request 
            var sendpaymentCanceler = $q.defer();

            // send payment
            function sendPayment(payment) {

                // show loading
                main.showLoading = true;

                // post the payment
                assignmentBackendService.sendPayment(sendpaymentCanceler, payment).then(
                   function (data) {
                       main.showLog = true;
                       main.log = $sce.trustAsHtml(data.data.Content);

                       main.showLoading = false;
                   },
                   function (data) {
                       alert(data.Message);

                       main.showLoading = false;
                   });
            }

            // hard coded payment 
            main.sendPaymentForMp3Player = function () {
                var mp3PlayerPayment = new Payment(main.mp3PlayerDescription, '2015/12/12', Status.Confiremd, 1, 100, 1);
                sendPayment(mp3PlayerPayment);
            }

            main.sendPaymentForBook = function () {
                var mp3PlayerPayment = new Payment(main.bookDescription, '2015/12/12', Status.Confiremd, 2, 10, 2);
                sendPayment(mp3PlayerPayment);
            }

            main.sendPaymentForMemberShip = function () {
                var mp3PlayerPayment = new Payment(main.membershipDescription, '2015/12/12', Status.Confiremd, 3, 10, 3);
                sendPayment(mp3PlayerPayment);
            }

            // release resources
            $scope.$on('$destroy', function () {
                sendpaymentCanceler.resolve();
            });
        }]);
