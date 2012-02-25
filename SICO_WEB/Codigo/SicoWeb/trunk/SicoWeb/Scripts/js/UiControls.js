$(function () {

	// Accordion
	$("#accordion").accordion({ header: "h3" });

	// Tabs
	$('#tabs').tabs();

    //Botones
	$("#agregarBotones").
    	button({ icons: {primary:'ui-icon-gear',secondary:'ui-icon-triangle-1-s'} });
    


	// Dialog			
	$('#dialog').dialog({
	    autoOpen: false,
	   
		modal:true
		
	});

	// Dialog Link
	$('#dialog_link').click(function () {
		$('#dialog').dialog('open');
		return false;
	});

	// Datepicker
	$('#datepicker').datepicker({
		inline: true
	});

	// Slider
	$('#slider').slider({
		range: true,
		values: [17, 67]
	});

	// Progressbar
	$("#progressbar").progressbar({
		value: 20
	});

	//hover states on the static widgets
	

});