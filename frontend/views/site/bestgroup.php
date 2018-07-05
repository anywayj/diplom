<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
use miloschuman\highcharts\Highcharts;
$this->title = 'Положення про кращу групу';
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


echo Highcharts::widget([ 
'options' => [ 
'chart' => ['type' => 'column'], 
'title' => ['text' => 'Графiк змiн'], 
'xAxis' => [ 
'categories' => ['CМ-14-1', 'CМ-15-1', 'CМ-16-1', 'CА-17-1', 'CМ-16-т', 'CА-17-т']
//'categories' => ['Ciтуацiя 1', [2], [7]], 'crosshair' => true 1
], 
'yAxis' => [[ 
'title' => ['text' => 'Величина розкиду'] 
] 
], 
'tooltip' => ['shared' => true], 
'series' => [ 
	['name' => 'Сумарна оцiнка груп за критеріями', 'type' => 'column', 'data' => [[74.02], [73.23],[74.16],[75.75],[72.17],[67.55]], 'tooltip' => []] 
	
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

    <div class="col-lg-6">    
        <?= $form->field($modelf, 'sessionStartdate')->label('Початок сесії (дата)') ?>
    </div>
    <div class="col-lg-6">
        <?= $form->field($modelf, 'sessionEnddate')->label('Кінцевий термін сесії (дата)') ?>
    </div>
</div>
	<div class="form-group">
        <?= Html::submitButton('Показати таблицю', ['class' => 'btn btn-primary']) ?>
    </div>
<?php ActiveForm::end(); ?>    
<table id="table" class="table table-bordered table-condensed"> 
    <thead>
            <tr>
                <th>Критерії / Групи</th>
            
               	<th>СМ-14-1</th>
        		<th>СМ-15-1</th>
        		<th>СМ-16-1</th>
        		<th>СА-17-1</th>
        		<th>СМ-16-т</th>
        		<th>СА-17-т</th>
            </tr>
            
    </thead>
    
    <tbody class="contant1">
			<tr>
				<td class="td1">Рейтинг</td>
				<td><?= $arr1[] = number_format(1608 / 26,2,'.', '')  ?></td>
				<td><?= $arr2[] = number_format(1374 / 22,2,'.', '')  ?></td>
				<td><?= $arr3[] = number_format(1250 / 19,2,'.', '')  ?></td>
				<td><?= $arr4[] = number_format(1199 / 20,2,'.', '')  ?></td>
				<td><?= $arr5[] = number_format(780  / 13,2,'.', '')  ?></td>
				<td><?= $arr6[] = number_format(1114 / 20,2,'.', '')  ?></td>
			</tr>
		
	
		<?php foreach($bestgroup as $k): ?> 
			<tr>
               	<td class="td1"><?= $k->name ?></td>
               	<td><?= $arr1[] = number_format(($k->rank_group / 26) * 4,2,'.', '')  ?></td>
               	<td><?= $arr2[] = number_format(($k->rank_group / 22) * 3,2,'.', '')  ?></td>
               	<td><?= $arr3[] = number_format(($k->rank_group / 19) * 2,2,'.', '')  ?></td>
               	<td><?= $arr4[] = number_format(($k->rank_group / 20) * 4,2,'.', '')  ?></td>
               	<td><?= $arr5[] = number_format(($k->rank_group / 13) * 2,2,'.', '')  ?></td>
               	<td><?= $arr6[] = number_format(($k->rank_group / 20) * 3,2,'.', '')  ?></td>
            </tr>
        <?php endforeach; ?>
		

		<?php foreach($bestgroupp as $k): ?> 
			<tr>
               	<td class="td1"><?= $k->name ?></td>
               	<td><?= $arr1[] = number_format(($k->rank_group / 26) * 4,2,'.', '')  ?></td>
               	<td><?= $arr2[] = number_format(($k->rank_group / 22) * 3,2,'.', '')  ?></td>
               	<td><?= $arr3[] = number_format(($k->rank_group / 19) * 2,2,'.', '')  ?></td>
               	<td><?= $arr4[] = number_format(($k->rank_group / 20) * 4,2,'.', '')  ?></td>
               	<td><?= $arr5[] = number_format(($k->rank_group / 13) * 2,2,'.', '')  ?></td>
                <td><?= $arr6[] = number_format(($k->rank_group / 20) * 3,2,'.', '')  ?></td>		
			</tr>
        <?php endforeach; ?>	

        <tr>
        	<th>Cума</th>
			<td class="td1"><?= $ar1 = array_sum($arr1)?></td>
			<td class="td1"><?= $ar2 = array_sum($arr2)?></td>
			<td class="td1"><?= $ar3 = array_sum($arr3)?></td>
			<td class="td2"><?= $ar4 = array_sum($arr4)?></td>
			<td class="td1"><?= $ar5 = array_sum($arr5)?></td>
			<td class="td1"><?= $ar6 = array_sum($arr6)?></td>
			
        </tr>
    </tbody>
</table>
		
	

<?php $this->endBody() ?>
</body>
</html>
<?php $this->endPage() ?>
