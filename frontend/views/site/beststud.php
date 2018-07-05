<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
use miloschuman\highcharts\Highcharts;
$this->title = 'Положення про кращого студента';
$this->params['breadcrumbs'][] = $this->title;
?>
<?php $this->beginPage() ?>
<!DOCTYPE html>
<html lang="<?= Yii::$app->language ?>">
<head>
<?php $this->head() ?>
</head>
<body>
<?php $this->beginBody() ?>
<h1 class="text-center"><?= Html::encode($this->title) ?></h1>
<div class="row">

<?php

$Discipline_dop1 = 'array (1,2,6);';
$Discipline_dop2 = 'array (1,12,8);';
$Discipline_dop3 = 'array (3,9,4);';

$X1bad_sr = array (1,2,6);
$X2bad_sr = array (1,12,8);
$X3bad_sr = array (3,1,4);



echo Highcharts::widget([ 
'options' => [ 
'chart' => ['type' => 'column'], 
'title' => ['text' => 'Графiк змiн'], 
'xAxis' => [ 
'categories' => ['Ареф’єва О.Б', 'Баган С.В.', 'Кадацкий Н.А.', 'Тушева А.А.', 'Булыга В.С.','Сигида О.А.']
//'categories' => ['Ciтуацiя 1', [2], [7]], 'crosshair' => true 1
], 
'yAxis' => [[ 
'title' => ['text' => 'Величина розкиду'] 
] 
], 
'tooltip' => ['shared' => true], 
'series' => [ 
  ['name' => 'Сумарна оцiнка студентiв за критеріями', 'type' => 'column', 'data' => [[16], [10],[2],[5],[7],[5]], 'tooltip' => []] 
  
] 
] 
]);

?>
<?php $form = ActiveForm::begin(); ?>
    <div class="col-lg-6">
        <?= $form->field($modelf, 'progressStartdate')->label('Початок аналізу (дата)') ?>
    </div>

    <div class="col-lg-6">    
        <?= $form->field($modelf, 'progressEnddate')->label('Кінцевий термін аналізу (дата)') ?>
    </div>
</div>
	<div class="form-group">
        <?= Html::submitButton('Показати таблицю', ['class' => 'btn btn-primary']) ?>
    </div>
<?php ActiveForm::end(); ?>    

<table id="table" class="table table-bordered table-condensed"> 
    <thead>
            <tr>
                <th>Критерії / ПIБ</th>
 
               
        	       <th>Ареф’єва О.Б</th>
                 <th>Баган С.В.</th>
                 <th>Кадацкий Н.А.</th>
                 <th>Тушева А.А.</th>
                 <th>Булыга В.С.</th>
                 <th>Сигида О.А.</th>
            </tr>
            
    </thead>
    
    <tbody class="contant1">


	
		<?php foreach($beststudd22 as $k): ?> 
			<tr>
               	<td class="td1"><?= $k->name ?></td>
               	<td><?= $k->rank_stud ?></td>
               	<td><?= $k->rank_stud ?></td>
               	<td><?= $k->rank_stud ?></td>
               	<td><?= $k->rank_stud ?></td>
               	<td><?= $k->rank_stud ?></td>
                <td><?= $k->rank_stud ?></td>
            </tr>
        <?php endforeach; ?>
		
		
	
    <tr>
		<th>Cума</th>
		<?php foreach($beststudd as $k): ?> 
			<?php $arrmax[]=$k->s1stud ?>
			<?php $max = max($arrmax);?>
				<?php if($max==$k->s1stud): ?>
               <td class="td2"><?= $k->s1stud ?></td>
                   <?php else: ?>  
                 <td class="td1"><?= $k->s1stud ?></td>
                 <?php endif ?>       
        <?php endforeach; ?>
	</tr>
    </tbody>
</table>
		
	
<?php

$Discipline_dop1 = 'array (1,2,6);';
$Discipline_dop2 = 'array (1,12,8);';
$Discipline_dop3 = 'array (3,9,4);';

$X1bad_sr = array (1,2,6);
$X2bad_sr = array (1,12,8);
$X3bad_sr = array (3,1,4);



echo Highcharts::widget([ 
'options' => [ 
'chart' => ['type' => 'column'], 
'title' => ['text' => 'Графiк змiн'], 
'xAxis' => [ 
'categories' => ['Ареф’єва О.Б', 'Баган С.В.', 'Кадацкий Н.А.', 'Тушева А.А.', 'Булыга В.С.','Сигида О.А.']
//'categories' => ['Ciтуацiя 1', [2], [7]], 'crosshair' => true 1
], 
'yAxis' => [[ 
'title' => ['text' => 'Величина розкиду'] 
] 
], 
'tooltip' => ['shared' => true], 
'series' => [ 
  ['name' => 'Сумарна оцiнка студентiв за критеріями', 'type' => 'column', 'data' => [[16], [10],[2],[5],[7],[5]], 'tooltip' => []] 
  
] 
] 
]);

?>
<?php $this->endBody() ?>
</body>
</html>
<?php $this->endPage() ?>

