<template>
    <div>
        <a :href="link.url" target="_blank" aria-current="true" rel="nofollow"
            class="rounded-lq list-group-item list-group-item-action d-flex gap-3 py-3" 
            :style="link.styleCss">
            <div class="rounded-circle flex-shrink-0">
                <i :class="link.icon + ' fa-2x'"></i>
            </div>
            <div class="d-flex gap-2 w-100 justify-content-between">
                <div>
                    <h6 class="mb-0">
                        {{link.title}}
                    </h6>
                    <p class="mb-0 opacity-75 text-resume">
                         {{link.description}}
                    </p>
                </div>
            </div>
        </a>
        <div style="height: 5px;"></div>
    </div>
</template>

<script>
export default {
  name: 'Botao',
  props: {
    link: {
      type: Object,
      required: true
    }
  }
}
</script>
