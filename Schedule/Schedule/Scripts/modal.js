$(document).ready(function () {

    $('body').on('click', '.modal-open', function (e) {
        e.preventDefault();
        var id = $(this).attr('id');
        $('.modal-info').css('opacity', '0').css('top',
            '-' + $('.modal-info').height() + 'px');

        if ($('meta[name="namepage"]').attr('content') == "Student") {
            if (id == 'this') {
                $('.modal-info .status-or-group p').text('Группа');
                $.post('/Student/GetModelStudent', function (data) {
                    data = JSON.parse(data);
                    $('.modal-info .firstname input').val(data.FirstName);
                    $('.modal-info .surname input').val(data.SurName);
                    $('.modal-info .lastname input').val(data.LastName);
                    $('.modal-info .status-or-group input').val(data.Group.Name);
                    ModalOpen();
                });
            } else {
                $('.modal-info .status-or-group p').text('Статус');
                $.post('/Student/GetModelTeacher', { Id: id }, function (data) {
                    data = JSON.parse(data);
                    $('.modal-info .firstname input').val(data.FirstName);
                    $('.modal-info .surname input').val(data.SurName);
                    $('.modal-info .lastname input').val(data.LastName);
                    $('.modal-info .status-or-group input').val(data.Status);
                    ModalOpen();
                });
            }
        }

        if ($('meta[name="namepage"]').attr('content') == "Teacher") {
                $('.modal-info .status-or-group p').text('Статус');
                $.post('/Teacher/GetModelTeacher', function (data) {
                    data = JSON.parse(data);
                    $('.modal-info .firstname input').val(data.FirstName);
                    $('.modal-info .surname input').val(data.SurName);
                    $('.modal-info .lastname input').val(data.LastName);
                    $('.modal-info .status-or-group input').val(data.Status);
                    ModalOpen();
                });
        }

    });

    function ModalOpen() {
        $('.stub').css('display', 'block');
        $('.modal-info').css('display', 'block').animate({
            opacity: 1,
            top: parseInt($('.stub').height() / 2 - 105) + 'px',
        }, {
            duration:1500,
            complete: function () {
                $('.modal-info').css('top', 'calc(50% - 105px)');
            }
        });
    }

    $('.stub').click(function () {
        $('.modal-info').css('display', 'none');
        $(this).css('display', 'none');
    });

});