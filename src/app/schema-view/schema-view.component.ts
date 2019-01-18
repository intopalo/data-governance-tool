import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Table, Schema, Field } from '../model/metadata.model';

@Component({
  selector: 'app-schema-view',
  templateUrl: './schema-view.component.html',
  styleUrls: ['./schema-view.component.css']
})
export class SchemaViewComponent implements OnInit {

    datastore:any = [];
	postgresDatabase:any = [];
	schema:any = [];
	tables:any = [];


	dbid:any = '';
 	schid:any = '';
 	dtsid:any = '';

	varform = 0;

	tableForm: FormGroup;
	SchemaId:number=null;
	Fields:string='';
	Name:string='';

	fieldForm: FormGroup;
	Type: string='';
	StructuredId: number=null;

    constructor(public rest:RestService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.dbid=this.route.snapshot.paramMap.get('dbId');
        this.schid=this.route.snapshot.paramMap.get('schemaId');
        this.dtsid=this.route.snapshot.paramMap.get('storeId');
        this.getDatastoreData();
        this.getPostgresDatabaseData(this.dbid);
        this.getSchemaData(this.schid);
        this.getTablesData();
        this.tableForm = this.formBuilder.group({
            'SchemaId' : this.schid,
            'Fields' : [],
            'Name' : [],
	   });
        this.fieldForm = this.formBuilder.group({
            'Type' : [],
            'StructuredId' : [],
            'Fields' : [],
            'Name' : [],
	   });
    }

    getDatastoreData() {
        this.datastore = [];
        this.rest.getDatastore(1).subscribe((data: {}) => {
          console.log(data);
          this.datastore = data;
        });
    }    
    
    getPostgresDatabaseData(id) {
        this.postgresDatabase = [];
        this.rest.getPostgresDatabase(id).subscribe((data: {}) => {
          console.log(data);
          this.postgresDatabase = data;
        });
    }    
    
    getSchemaData(id) {
        this.schema = [];
        this.rest.getSchema(id).subscribe((data: {}) => {
          console.log(data);
          this.schema = data;
        });
    }    
    
    getTablesData() {
        this.tables = [];
        this.rest.getTables().subscribe((data: {}) => {
          console.log(data);
          this.tables = data;
        });
    }    

	addPostgresTable() {
		this.rest.addTable(this.tableForm.value).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getTablesData();
		});
	}

	addPostgresField() {
		this.rest.addField(this.fieldForm.value).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getTablesData();
		});
	}

    	deleteSchema(){
  		this.rest.deleteSchema(this.schema.Id).subscribe((data: {}) => {
  			this.router.navigate(['/store/'+ this.dtsid +'/postgres/'+ this.dbid]);
		});
	}
    	deleteTable(id){
  		this.rest.deleteTable(id).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getTablesData();
		});
	}
    	deleteField(id){
  		this.rest.deleteField(id).subscribe((data: {}) => {
	  	        this.getSchemaData(this.schid);
			this.getTablesData();
		});
	}
    backToHome() {
        this.router.navigate(['/store/'+ this.dtsid]);
    } 
 

    backToPostgresDatabase() {
        this.router.navigate(['/store/'+ this.dtsid +'/postgres/'+ this.dbid]);
    }

  
}
