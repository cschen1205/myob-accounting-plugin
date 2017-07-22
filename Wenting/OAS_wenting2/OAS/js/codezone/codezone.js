$(document).ready(function(){
    $('#topmenu td').addClass('topmenuitem');
    $('#mainform').addClass('mainform');
    
    $('#topmenu td').hover(function(){
        $(this).addClass('topmenuitemhover');
        }, function(){
        $(this).removeClass('topmenuitemhover');
        }
    );
    
    $('#Sales').click(function(){
        window.location='Sales.aspx';
    });
    $('#Purchases').click(function(){
    });
    $('#ItemsAndInventory').click(function(){
    });
    $('#Manufacturing').click(function(){
        window.location='Manufacturing.aspx';
    });
    $('#Dimensions').click(function(){
    });
    $('#GeneralLedger').click(function(){
        window.location='GeneralLedger.aspx';
    });
    $('#Setup').click(function(){
        window.location='Setup.aspx';
    });
});