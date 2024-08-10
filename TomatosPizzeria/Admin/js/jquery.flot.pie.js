// JavaScript Document
(function($){var REDRAW_ATTEMPTS=10;var REDRAW_SHRINK=0.95;function init(plot){var canvas=null,target=null,options=null,maxRadius=null,centerLeft=null,centerTop=null,processed=false,ctx=null;var highlights=[];plot.hooks.processOptions.push(function(plot,options){if(options.series.pie.show){options.grid.show=false;if(options.series.pie.label.show=="auto"){if(options.legend.show){options.series.pie.label.show=false;}else{options.series.pie.label.show=true;}}
if(options.series.pie.radius=="auto"){if(options.series.pie.label.show){options.series.pie.radius=3/4;}else{options.series.pie.radius=1;}}
if(options.series.pie.tilt>1){options.series.pie.tilt=1;}else if(options.series.pie.tilt<0){options.series.pie.tilt=0;}}});plot.hooks.bindEvents.push(function(plot,eventHolder){var options=plot.getOptions();if(options.series.pie.show){if(options.grid.hoverable){eventHolder.unbind("mousemove").mousemove(onMouseMove);}
if(options.grid.clickable){eventHolder.unbind("click").click(onClick);}}});plot.hooks.processDatapoints.push(function(plot,series,data,datapoints){var options=plot.getOptions();if(options.series.pie.show){processDatapoints(plot,series,data,datapoints);}});plot.hooks.drawOverlay.push(function(plot,octx){var options=plot.getOptions();if(options.series.pie.show){drawOverlay(plot,octx);}});plot.hooks.draw.push(function(plot,newCtx){var options=plot.getOptions();if(options.series.pie.show){draw(plot,newCtx);}});function processDatapoints(plot,series,datapoints){if(!processed){processed=true;canvas=plot.getCanvas();target=$(canvas).parent();options=plot.getOptions();plot.setData(combine(plot.getData()));}}
function combine(data){var total=0,combined=0,numCombined=0,color=options.series.pie.combine.color,newdata=[];for(var i=0;i<data.length;++i){var value=data[i].data;if($.isArray(value)&&value.length==1){value=value[0];}
if($.isArray(value)){if(!isNaN(parseFloat(value[1]))&&isFinite(value[1])){value[1]=+value[1];}else{value[1]=0;}}else if(!isNaN(parseFloat(value))&&isFinite(value)){value=[1,+value];}else{value=[1,0];}
data[i].data=[value];}
for(var i=0;i<data.length;++i){total+=data[i].data[0][1];}
for(var i=0;i<data.length;++i){var value=data[i].data[0][1];if(value/total<=options.series.pie.combine.threshold){combined+=value;numCombined++;if(!color){color=data[i].color;}}}
for(var i=0;i<data.length;++i){var value=data[i].data[0][1];if(numCombined<2||value/total>options.series.pie.combine.threshold){newdata.push($.extend(data[i],{data:[[1,value]],color:data[i].color,label:data[i].label,angle:value*Math.PI*2/total,percent:value/(total/100)}));}}
if(numCombined>1){newdata.push({data:[[1,combined]],color:color,label:options.series.pie.combine.label,angle:combined*Math.PI*2/total,percent:combined/(total/100)});}
return newdata;}
function draw(plot,newCtx){if(!target){return;}
var canvasWidth=plot.getPlaceholder().width(),canvasHeight=plot.getPlaceholder().height(),legendWidth=target.children().filter(".legend").children().width()||0;ctx=newCtx;processed=false;maxRadius=Math.min(canvasWidth,canvasHeight/options.series.pie.tilt)/ 2;
centerTop=canvasHeight/2+ options.series.pie.offset.top;centerLeft=canvasWidth/2;if(options.series.pie.offset.left=="auto"){if(options.legend.position.match("w")){centerLeft+=legendWidth/2;}else{centerLeft-=legendWidth/2;}
if(centerLeft<maxRadius){centerLeft=maxRadius;}else if(centerLeft>canvasWidth- maxRadius){centerLeft=canvasWidth- maxRadius;}}else{centerLeft+=options.series.pie.offset.left;}
var slices=plot.getData(),attempts=0;do{if(attempts>0){maxRadius*=REDRAW_SHRINK;}
attempts+=1;clear();if(options.series.pie.tilt<=0.8){drawShadow();}}while(!drawPie()&&attempts<REDRAW_ATTEMPTS)
if(attempts>=REDRAW_ATTEMPTS){clear();target.prepend("<div class='error'>Could not draw pie with labels contained inside canvas</div>");}
if(plot.setSeries&&plot.insertLegend){plot.setSeries(slices);plot.insertLegend();}
function clear(){ctx.clearRect(0,0,canvasWidth,canvasHeight);target.children().filter(".pieLabel, .pieLabelBackground").remove();}
function drawShadow(){var shadowLeft=options.series.pie.shadow.left;var shadowTop=options.series.pie.shadow.top;var edge=10;var alpha=options.series.pie.shadow.alpha;var radius=options.series.pie.radius>1?options.series.pie.radius:maxRadius*options.series.pie.radius;if(radius>=canvasWidth/2- shadowLeft||radius*options.series.pie.tilt>=canvasHeight/2- shadowTop||radius<=edge){return;}
ctx.save();ctx.translate(shadowLeft,shadowTop);ctx.globalAlpha=alpha;ctx.fillStyle="#000";ctx.translate(centerLeft,centerTop);ctx.scale(1,options.series.pie.tilt);for(var i=1;i<=edge;i++){ctx.beginPath();ctx.arc(0,0,radius,0,Math.PI*2,false);ctx.fill();radius-=i;}
ctx.restore();}
function drawPie(){var startAngle=Math.PI*options.series.pie.startAngle;var radius=options.series.pie.radius>1?options.series.pie.radius:maxRadius*options.series.pie.radius;ctx.save();ctx.translate(centerLeft,centerTop);ctx.scale(1,options.series.pie.tilt);ctx.save();var currentAngle=startAngle;for(var i=0;i<slices.length;++i){slices[i].startAngle=currentAngle;drawSlice(slices[i].angle,slices[i].color,true);}
ctx.restore();if(options.series.pie.stroke.width>0){ctx.save();ctx.lineWidth=options.series.pie.stroke.width;currentAngle=startAngle;for(var i=0;i<slices.length;++i){drawSlice(slices[i].angle,options.series.pie.stroke.color,false);}
ctx.restore();}
drawDonutHole(ctx);ctx.restore();if(options.series.pie.label.show){return drawLabels();}else return true;function drawSlice(angle,color,fill){if(angle<=0||isNaN(angle)){return;}
if(fill){ctx.fillStyle=color;}else{ctx.strokeStyle=color;ctx.lineJoin="round";}
ctx.beginPath();if(Math.abs(angle- Math.PI*2)>0.000000001){ctx.moveTo(0,0);}
ctx.arc(0,0,radius,currentAngle,currentAngle+ angle/2,false);ctx.arc(0,0,radius,currentAngle+ angle/2,currentAngle+ angle,false);ctx.closePath();currentAngle+=angle;if(fill){ctx.fill();}else{ctx.stroke();}}
function drawLabels(){var currentAngle=startAngle;var radius=options.series.pie.label.radius>1?options.series.pie.label.radius:maxRadius*options.series.pie.label.radius;for(var i=0;i<slices.length;++i){if(slices[i].percent>=options.series.pie.label.threshold*100){if(!drawLabel(slices[i],currentAngle,i)){return false;}}
currentAngle+=slices[i].angle;}
return true;function drawLabel(slice,startAngle,index){if(slice.data[0][1]==0){return true;}
var lf=options.legend.labelFormatter,text,plf=options.series.pie.label.formatter;if(lf){text=lf(slice.label,slice);}else{text=slice.label;}
if(plf){text=plf(text,slice);}
var halfAngle=((startAngle+ slice.angle)+ startAngle)/ 2;
var x=centerLeft+ Math.round(Math.cos(halfAngle)*radius);var y=centerTop+ Math.round(Math.sin(halfAngle)*radius)*options.series.pie.tilt;var html="<span class='pieLabel' id='pieLabel"+ index+"' style='position:absolute;top:"+ y+"px;left:"+ x+"px;'>"+ text+"</span>";target.append(html);var label=target.children("#pieLabel"+ index);var labelTop=(y- label.height()/ 2);
var labelLeft=(x- label.width()/ 2);
label.css("top",labelTop);label.css("left",labelLeft);if(0- labelTop>0||0- labelLeft>0||canvasHeight-(labelTop+ label.height())<0||canvasWidth-(labelLeft+ label.width())<0){return false;}
if(options.series.pie.label.background.opacity!=0){var c=options.series.pie.label.background.color;if(c==null){c=slice.color;}
var pos="top:"+ labelTop+"px;left:"+ labelLeft+"px;";$("<div class='pieLabelBackground' style='position:absolute;width:"+ label.width()+"px;height:"+ label.height()+"px;"+ pos+"background-color:"+ c+";'></div>").css("opacity",options.series.pie.label.background.opacity).insertBefore(label);}
return true;}}}}
function drawDonutHole(layer){if(options.series.pie.innerRadius>0){layer.save();var innerRadius=options.series.pie.innerRadius>1?options.series.pie.innerRadius:maxRadius*options.series.pie.innerRadius;layer.globalCompositeOperation="destination-out";layer.beginPath();layer.fillStyle=options.series.pie.stroke.color;layer.arc(0,0,innerRadius,0,Math.PI*2,false);layer.fill();layer.closePath();layer.restore();layer.save();layer.beginPath();layer.strokeStyle=options.series.pie.stroke.color;layer.arc(0,0,innerRadius,0,Math.PI*2,false);layer.stroke();layer.closePath();layer.restore();}}
function isPointInPoly(poly,pt){for(var c=false,i=-1,l=poly.length,j=l- 1;++i<l;j=i)
((poly[i][1]<=pt[1]&&pt[1]<poly[j][1])||(poly[j][1]<=pt[1]&&pt[1]<poly[i][1]))&&(pt[0]<(poly[j][0]- poly[i][0])*(pt[1]- poly[i][1])/ (poly[j][1] - poly[i][1]) + poly[i][0])
&&(c=!c);return c;}
function findNearbySlice(mouseX,mouseY){var slices=plot.getData(),options=plot.getOptions(),radius=options.series.pie.radius>1?options.series.pie.radius:maxRadius*options.series.pie.radius,x,y;for(var i=0;i<slices.length;++i){var s=slices[i];if(s.pie.show){ctx.save();ctx.beginPath();ctx.moveTo(0,0);ctx.arc(0,0,radius,s.startAngle,s.startAngle+ s.angle/2,false);ctx.arc(0,0,radius,s.startAngle+ s.angle/2,s.startAngle+ s.angle,false);ctx.closePath();x=mouseX- centerLeft;y=mouseY- centerTop;if(ctx.isPointInPath){if(ctx.isPointInPath(mouseX- centerLeft,mouseY- centerTop)){ctx.restore();return{datapoint:[s.percent,s.data],dataIndex:0,series:s,seriesIndex:i};}}else{var p1X=radius*Math.cos(s.startAngle),p1Y=radius*Math.sin(s.startAngle),p2X=radius*Math.cos(s.startAngle+ s.angle/4),p2Y=radius*Math.sin(s.startAngle+ s.angle/4),p3X=radius*Math.cos(s.startAngle+ s.angle/2),p3Y=radius*Math.sin(s.startAngle+ s.angle/2),p4X=radius*Math.cos(s.startAngle+ s.angle/1.5),p4Y=radius*Math.sin(s.startAngle+ s.angle/1.5),p5X=radius*Math.cos(s.startAngle+ s.angle),p5Y=radius*Math.sin(s.startAngle+ s.angle),arrPoly=[[0,0],[p1X,p1Y],[p2X,p2Y],[p3X,p3Y],[p4X,p4Y],[p5X,p5Y]],arrPoint=[x,y];if(isPointInPoly(arrPoly,arrPoint)){ctx.restore();return{datapoint:[s.percent,s.data],dataIndex:0,series:s,seriesIndex:i};}}
ctx.restore();}}
return null;}
function onMouseMove(e){triggerClickHoverEvent("plothover",e);}
function onClick(e){triggerClickHoverEvent("plotclick",e);}
function triggerClickHoverEvent(eventname,e){var offset=plot.offset();var canvasX=parseInt(e.pageX- offset.left);var canvasY=parseInt(e.pageY- offset.top);var item=findNearbySlice(canvasX,canvasY);if(options.grid.autoHighlight){for(var i=0;i<highlights.length;++i){var h=highlights[i];if(h.auto==eventname&&!(item&&h.series==item.series)){unhighlight(h.series);}}}
if(item){highlight(item.series,eventname);}
var pos={pageX:e.pageX,pageY:e.pageY};target.trigger(eventname,[pos,item]);}
function highlight(s,auto){var i=indexOfHighlight(s);if(i==-1){highlights.push({series:s,auto:auto});plot.triggerRedrawOverlay();}else if(!auto){highlights[i].auto=false;}}
function unhighlight(s){if(s==null){highlights=[];plot.triggerRedrawOverlay();}
var i=indexOfHighlight(s);if(i!=-1){highlights.splice(i,1);plot.triggerRedrawOverlay();}}
function indexOfHighlight(s){for(var i=0;i<highlights.length;++i){var h=highlights[i];if(h.series==s)
return i;}
return-1;}
function drawOverlay(plot,octx){var options=plot.getOptions();var radius=options.series.pie.radius>1?options.series.pie.radius:maxRadius*options.series.pie.radius;octx.save();octx.translate(centerLeft,centerTop);octx.scale(1,options.series.pie.tilt);for(var i=0;i<highlights.length;++i){drawHighlight(highlights[i].series);}
drawDonutHole(octx);octx.restore();function drawHighlight(series){if(series.angle<=0||isNaN(series.angle)){return;}
octx.fillStyle="rgba(255, 255, 255, "+ options.series.pie.highlight.opacity+")";octx.beginPath();if(Math.abs(series.angle- Math.PI*2)>0.000000001){octx.moveTo(0,0);}
octx.arc(0,0,radius,series.startAngle,series.startAngle+ series.angle/2,false);octx.arc(0,0,radius,series.startAngle+ series.angle/2,series.startAngle+ series.angle,false);octx.closePath();octx.fill();}}}
var options={series:{pie:{show:false,radius:"auto",innerRadius:0,startAngle:3/2,tilt:1,shadow:{left:5,top:15,alpha:0.02},offset:{top:0,left:"auto"},stroke:{color:"#fff",width:1},label:{show:"auto",formatter:function(label,slice){return"<div style='font-size:x-small;text-align:center;padding:2px;color:"+ slice.color+";'>"+ label+"<br/>"+ Math.round(slice.percent)+"%</div>";},radius:1,background:{color:null,opacity:0},threshold:0},combine:{threshold:-1,color:null,label:"Other"},highlight:{opacity:0.5}}}};$.plot.plugins.push({init:init,options:options,name:"pie",version:"1.1"});})(jQuery);