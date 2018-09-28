
function loadDateTime(startSelector, endSelector, targetSelector) {

    $(startSelector).datetimepicker({
        locale: "pt-br"
    });
    $(endSelector).datetimepicker({
        locale: "pt-br",
        useCurrent: false //Important! See issue #1075
    });

    $(startSelector).on("dp.change", function (e) {
        $(endSelector).data("DateTimePicker").minDate(e.date);
        if (targetSelector !== null) {
            calculateInterval(startSelector, endSelector, targetSelector);
        }
    });
    $(endSelector).on("dp.change", function (e) {
        $(startSelector).data("DateTimePicker").maxDate(e.date);
        if (targetSelector !== null) {
            calculateInterval(startSelector, endSelector, targetSelector);
        }
    });

    $(".panel-body").css("overflow", "visible");

}

function loadDatesAndDuration($start, $end, $total, $duration) {

    $start.datetimepicker({
        locale: "pt-br"
    });
    $end.datetimepicker({
        locale: "pt-br"
    });
    $start.on("dp.change", function (e) {
        $end.data("DateTimePicker").minDate(e.date);
        if ($duration !== null) {
            calculateDuration($start, $end, $total, $duration);
        }
    });
    $end.on("dp.change", function (e) {
        $start.data("DateTimePicker").maxDate(e.date);
        if ($duration !== null) {
            calculateDuration($start, $end, $total, $duration);
        }
    });

}

function loadMinDate(dateSelector, minDateSelector) {
    $(dateSelector).datetimepicker({
        locale: "pt-br"
    });
    $(dateSelector).on("dp.change", function (e) {
        $(minDateSelector).data().minDate(e.date);
    });
}

function loadMonthDate(startSelector, endSelector) {

    $(startSelector).datetimepicker({
        format: "MMM YYYY",
        locale: "pt-br"
    });

    $(endSelector).datetimepicker({
        locale: "pt-br",
        format: "MMM YYYY",
        useCurrent: false //Important! See issue #1075
    });

    $(startSelector).on("dp.change", function (e) {
        $(endSelector).data("DateTimePicker").minDate(e.date);
    });

    $(endSelector).on("dp.change", function (e) {
        $(startSelector).data("DateTimePicker").maxDate(e.date);
    });

    $(".panel-body").css("overflow", "visible");
}

function calculateInterval(startId, endId, durationId) {

    var $start = $(startId);
    var start = $start.data().date;
    var $end = $(endId);
    var end = $end.data().date;
    var $duration = $(durationId);

    if (start && end) {
        if (start.length > 9 && end.length > 9) {
            var startParts = start.substring(0, 10).split("/");
            var onlyStartTime = start.substring(10).split(":");
            var from = new Date(startParts[2], startParts[1] - 1, startParts[0], onlyStartTime[0], onlyStartTime[1]);

            var endParts = end.substring(0, 10).split("/");
            var onlyEndTime = end.substring(10).split(":");
            var to = new Date(endParts[2], endParts[1] - 1, endParts[0], onlyEndTime[0], onlyEndTime[1]);

            var interval = to.getTime() - from.getTime();
            var ms = interval;
            ms = ms / 1000;
            //var seconds = Math.floor(ms % 60);
            ms = ms / 60;
            var minutes = Math.floor(ms % 60);
            ms = ms / 60;
            var hours = Math.floor(ms % 24);
            var days = Math.floor(ms / 24);

            $duration.val(days + " " + twoPlaces(hours) + ":" + twoPlaces(minutes));
            $duration.prop("readonly", true);

            var $total = $(startId).closest(".tab-pane").find(".totalMinutes");
            var intervalInMinutes = Math.floor((interval / 1000) / 60);

            $total.val(intervalInMinutes);
        }
    }
}

function twoPlaces(value) {
    if (value < 10) {
        return "0" + value;
    }
    return value;
};

function toStringDate(pDate) {
    if (pDate !== null && pDate !== undefined) {
        var date = (new Date(parseInt(pDate.substr(6))));
        var output = ("0" + date.getDate()).slice(-2)
            + "\/" + ("0" + (date.getMonth() + 1)).slice(-2)
            + "\/" + date.getFullYear() + " "
            + ("0" + date.getHours()).slice(-2)
            + ":" + ("0" + date.getMinutes()).slice(-2);
        return output;
    }
    return "";
}

function calculateDuration($start, $end, $total, $duration) {
    var start = $start.data().date;
    var end = $end.data().date;
}

