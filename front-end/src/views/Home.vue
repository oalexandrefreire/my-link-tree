<template>
  <div v-if="customer != null">
    <div id="profile" class="container-fluid">
        <div class="list-group">
            <center id="cabecalho-padrao">
                <div class="col-lg-12">
                    <img :alt="'Imagem de  '+ customer.name" :src="customer.imageUrl" width="110" height="110" class="rounded-circle" />
                    <h2>
                      {{customer.name}}
                    </h2>
                    <p style="max-width:80%"> {{customer.description}}</p>
                </div>
            </center>

            <center id="cabecalho-resumido" class="link-bio-template" onclick="GoTop()" style="display:none">
                <div class="container-fluid row" style="max-width: 460px;">
                    <div class="col-md-3" style="width: 25%;">
                        <img :alt="'Imagem de  '+ customer.name" :src="customer.imageUrl" width="70" height="70" class="rounded-circle" />
                    </div>
                    <div class="col-md-9" style="width: 75%;text-align: left;">
                        <h2>{{customer.name}}</h2>
                        <p class="text-resume">
                            {{customer.description}}
                        </p>
                    </div>
                </div>
                <br />
                <br />
            </center>
            <botao v-for="link in links" v-bind:key="link" :link="link"></botao>
            <div style="height: 100px"></div>
        </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import Botao from '@/components/Botao.vue'

export default {
  name: 'Home',
  data() {
    return {
      customer: null,
      links: null
    }
  },
  components: {
    Botao
  },
  methods: {
    GoTop(){
      window.scrollTo({ top: 0, behavior: 'smooth' });
    }
  },
  beforeCreate(){
      $.getJSON("https://linksbio.app.portosites.com.br/api/LinksApi/alexandrefreire", (data) => {
            this.customer = data.customer;
            this.links = data.links;
            $('head').append('<style type="text/css">body{'+ this.customer.template.styleCss +'} .link-bio-template{'+ this.customer.template.styleCss +'}</style>');      
            
            if(this.customer.isIndexable != true){
                $('head').append('<meta name="robots" content="noindex, nofollow">');
            }

            $('head').append('<meta name="description" content="'+ this.customer.description +'">');
            $('head').append('<meta name="og:title" property="og:title" content="Links - '+ this.customer.name +'">');
            $('head').append('<meta name="twitter:card" content="Links - '+ this.customer.name +'">'); 
        });
  },
  mounted(){
        $(window).bind('mousewheel scroll', function(event) {
            console.log(event.originalEvent.wheelDelta)
            console.log($(this).scrollTop())
            if ($(this).scrollTop() <= 100) {
                console.log('Scroll up');
                $("#cabecalho-resumido").css("display", "none");
            }
            else {
                console.log('Scroll down');
                $("#cabecalho-resumido").css("display", "block");
            }
        });

  },

}
</script>

<style>

.center {
    text-align: center;
}
.center > div, .center > table /* insert any other block-level elements here */ {
    margin-left: auto;
    margin-right: auto;
}

.b-example-divider {
    height: 3rem;
    background-color: rgba(0, 0, 0, .1);
    border: solid rgba(0, 0, 0, .15);
    border-width: 1px 0;
    box-shadow: inset 0 .5em 1.5em rgba(0, 0, 0, .1), inset 0 .125em .5em rgba(0, 0, 0, .15);
}

.bi {
    vertical-align: -.125em;
    fill: currentColor;
}

.opacity-50 {
    opacity: .5;
}

.opacity-75 {
    opacity: .75;
}

.list-group {
    width: auto;
    max-width: 460px;
    margin: 1.5rem auto;
}

.form-check-input:checked + .form-checked-content {
    opacity: .5;
}

.form-check-input-placeholder {
    pointer-events: none;
    border-style: dashed;
}

[contenteditable]:focus {
    outline: 0;
}

.list-group-checkable {
    display: grid;
    gap: .5rem;
    border: 0;
}

    .list-group-checkable .list-group-item {
        cursor: pointer;
        border-radius: .5rem;
    }

.list-group-item-check {
    position: absolute;
    clip: rect(0, 0, 0, 0);
    pointer-events: none;
}

    .list-group-item-check:hover + .list-group-item {
        background-color: var(--bs-light);
    }

    .list-group-item-check:checked + .list-group-item {
        color: #fff;
        background-color: var(--bs-blue);
    }

    .list-group-item-check[disabled] + .list-group-item,
    .list-group-item-check:disabled + .list-group-item {
        pointer-events: none;
        filter: none;
        opacity: .5;
    }

footer {
    position: fixed;
    height: 50px;
    bottom: 0;
    width: 100%;
    background-color: white;
    padding-top: 10px;
}

.rounded-lq {
    border-radius: 3rem !important;
}

.not-found {
    height: 100px;
    line-height: 100px;
    text-align: center;
    border: 2px dashed #f69c55;
}


#cabecalho-resumido {
    display: block;
    position: fixed;
    top: 0;
    left: 0;
    z-index: 999;
    width: 100%;
    height: 90px;
    padding-top: 10px;
    border-radius: 0px 0px 20px 20px;
}


.text-resume {
    overflow: hidden !important;
    text-overflow: ellipsis !important;
    display: -webkit-box !important;
    -webkit-box-orient: vertical !important;
    -webkit-line-clamp: 1 !important;
    line-clamp: 1 !important;
}
</style>
