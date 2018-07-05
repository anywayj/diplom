$(document).ready(function () {

    var Day;

    $('.menu-cell').click(function () {
        $('.menu-cell').removeClass('active');
        $(this).addClass('active');
        Day = $(this).data('day');


        for (var i = 0; i < $('.schedule-day-time').length; i++) {
            $($('.schedule-day-time .schedule-day-time-text').get(i)).children('p:eq(0)').
                text((Day < 5) ? ($($('.schedule-day-time').get(i)).
                    data('start').split('|')[0]) :
                    ($($('.schedule-day-time').get(i)).
                        data('start').split('|')[1]));

            $($('.schedule-day-time .schedule-day-time-text').get(i)).children('p:eq(2)').
                text((Day < 5) ? ($($('.schedule-day-time').get(i)).
                    data('end').split('|')[0]) :
                    ($($('.schedule-day-time').get(i)).
                        data('start').split('|')[1]));
        }

        if (Day < 5)
            $('.schedule-day-time:eq(4) p').css('display', 'block');
        else 
            $('.schedule-day-time:eq(4) p').css('display', 'none');

        $('.schedule-cell .lesson-name').text('');
        $('.schedule-cell .teachers').html('');
        $('.schedule-cell .groups').text('');

        $('.schedule-block .loader').css('display', 'block');

        if ($('meta[name="namepage"]').attr('content') == "Student") {
            $.post('/Student/GetSchedule', { DayOfWeek: Day }, function (data) {
                data = JSON.parse(data);
                for (var i = 0; i < data.length; i++) {
                    $('.schedule-cell:eq(' + (data[i].NumLesson - 1) + ') .lesson-name').
                        text(data[i].Name);
                    for (var j = 0; j < data[i].Teachers.length; j++) {

                        var nameTeacher = data[i].Teachers[j].Status + ' '
                            + data[i].Teachers[j].FirstName + ' ' +
                            data[i].Teachers[j].SurName + ' ' +
                            data[i].Teachers[j].LastName;
                        var IdTeacher = data[i].Teachers[j].Id;

                        $('.schedule-cell:eq(' + (data[i].NumLesson - 1) + ') .teachers').
                            append('<a href="#" class="modal-open" id="' + IdTeacher + '">'
                                + nameTeacher + '</a>')

                        if (j != data[i].Teachers.length - 1)
                            $('.schedule-cell:eq(' + (data[i].NumLesson - 1) + ') .teachers').
                                append(', ');
                    }
                }
                $('.schedule-block .loader').css('display', 'none');
            });
        }

        if ($('meta[name="namepage"]').attr('content') == "Teacher") {
            $.post('/Teacher/GetSchedule', { DayOfWeek: Day }, function (data) {
                data = JSON.parse(data);
                for (var i = 0; i < data.length; i++) {
                    $('.schedule-cell:eq(' + (data[i].NumLesson - 1) + ') .lesson-name').
                        text(data[i].Name);
                    $('.schedule-cell:eq(' + (data[i].NumLesson - 1) + ') .groups').
                        text(data[i].GroupName);
                }
                $('.schedule-block .loader').css('display', 'none');
            });
        }


    });

    if (new Date().getDay() < 6 && new Date().getDay() != 0)
        $('.menu-cell[data-day="'
            + new Date().getDay() + '"]').click();
    else
        $('.menu-cell[data-day="1"]').click();

});