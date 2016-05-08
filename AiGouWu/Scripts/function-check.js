function check_all(checkbox) {
 //$('input[type=checkbox]').attr('checked', $(checkbox).attr('checked'));

     if ($(checkbox).attr("checked"))
     {
        $(".checkall input").attr("checked", true);
     }
    else 
    {

        $(".checkall input").attr("checked", false);
    }
   
}
